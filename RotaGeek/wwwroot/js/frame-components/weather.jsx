var Weather = React.createClass({

    getInitialState: function () {
        return {
            location: "london",
        }
    },

    componentWillMount: function () {
        //TODO: refactor: one source of truth
        if ("geolocation" in navigator) {
            navigator.geolocation.getCurrentPosition(this.handleGeolocationSuccess, this.handleGeolocationError);
        } else {
            this.getWeather("london");
        }
    },
   
    getWeather: function () {
        var urlWithLocation = window.location.origin + "/weather/getweather?q=" + this.state.location;
        this.httpGet(urlWithLocation, this.handleWeatherloadState);
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
    },

    getLocationByLatLng: function (lat, long, completionHandler) {
        var urlWithLatLng = "http://maps.googleapis.com/maps/api/geocode/json?latlng=" + lat + "," + long + "&sensor=true";
        this.httpGet(urlWithLatLng, this.handleFetchUserLocation(completionHandler));
    },

    handleFetchUserLocation: function (completionHandler) {
        return function (e) {
            var response = JSON.parse(e.target.responseText),
                location = response.results[0].address_components[0].short_name;

            this.setState({ location: location });

            completionHandler(location);
        }.bind(this);
    },

    handleWeatherloadState: function (e) {
        var response = JSON.parse(e.target.responseText);

        if (e.target.status == 200) {
            this.handleWeatherWidgetUpdate(response);
        }
    },

    handleWeatherWidgetUpdate: function (response) {
        this.setState({
            weatherImg: response.current.condition.icon,
            weather: response.current.condition.text,
            fahrenheit: response.current["temp_F"],
            celsius: response.current["temp_c"],
        });
    },

    handleGeolocationSuccess: function (p) {
        this.getLocationByLatLng(p.coords.latitude, p.coords.longitude, function (location) {
            this.getWeather(location);
        }.bind(this));
    },

    handleGeolocationError: function () {
        this.getWeather("london");
    },

    httpGet: function (url, loadStateHandler) {
        var xhr = new XMLHttpRequest();
        xhr.addEventListener("load", loadStateHandler);
        xhr.open("GET", url, true);
        xhr.send();
    },
})