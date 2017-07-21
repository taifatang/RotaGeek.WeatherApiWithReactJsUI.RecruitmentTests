var Query = React.createClass({

    getInitialState: function() {
        return {
            data:[]
        }
    },

    fetchFromServer: function () {

        var xhr = new XMLHttpRequest();

        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        }.bind(this);

        xhr.open('GET', this.props.url, true);
        xhr.send();
    },

    poll: function () {
        this.fetchFromServer();
        window.setInterval(this.fetchFromServer, this.props.pollInterval);
    },

    render: function () {
        return (
            <div className="tab-content">
                <pre>{this.props.result || "Hello!"}</pre>
            </div>
        );
    }
})