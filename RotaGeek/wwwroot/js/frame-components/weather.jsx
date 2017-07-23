var Weather = React.createClass({

    getInitialState: function () {
        return {
            location: "london",
        }
    },

    getWeather: function () {
        var url = window.location.origin + "/weather/getweather?q=" + this.state.location;
        this.httpGet(url, this.handleWeatherloadState);
    },

    componentWillMount: function () {
        console.log(this.state.location);
        if ("geolocation" in navigator) {
            navigator.geolocation.getCurrentPosition(function (p) {
                this.getLocationByLatLng(p.coords.latitude, p.coords.longitude, function (location) {
                    this.getWeather(location);
                }.bind(this));
            }.bind(this));
            return;
        };

        this.getWeather("london");
    },

    getLocationByLatLng: function (lat, long, callBack) {
        var url = "http://maps.googleapis.com/maps/api/geocode/json?latlng=" + lat + "," + long + "&sensor=true";

        this.httpGet(url,
            function (e) {
                var response = JSON.parse(e.target.responseText);
                var location = response.results[0].address_components[0].short_name;
                this.setState({ location: location });
                callBack(location);
            }.bind(this));
    },

    httpGet: function (url, loadStateHandler) {
        console.log(url);
        var xhr = new XMLHttpRequest();
        xhr.addEventListener("load", loadStateHandler);
        xhr.open("GET", url, true);
        xhr.send();
    },

    handleWeatherloadState: function (e) {
        var response = JSON.parse(e.target.responseText);
        console.log(e.target.responseText);
        if (e.target.status == 200) {
            this.setState({
                weatherImg: response.current.condition.icon,
                weather: response.current.condition.text,
                fahrenheit: response.current["temp_F"],
                celsius: response.current["temp_c"],
            });
        }
    },

    render: function () {
        return (
            <div>
                Location: {this.state.location}
                <br />
                Celsius: {this.state.celsius}C Fahrenheit: {this.state.fahrenheit}
                <br />
                Weather: {this.state.weather}
                <br />
                <img className="img-responsive" src={this.state.weatherImg} />
            </div>
        );
    }
})