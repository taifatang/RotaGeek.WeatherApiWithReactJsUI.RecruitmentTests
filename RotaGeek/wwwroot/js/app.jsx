var App = React.createClass({

    getInitialState: function () {
        return {
            queries: [],
            networkState: "{ Hello! }"
        }
    },

    fetchFromServer: function () {
        console.log("polling");
        var xhr = new XMLHttpRequest();
        xhr.open('GET', this.props.queriesGetUrl, true);
        xhr.addEventListener("load", this.handleXHRStateChange);
        xhr.addEventListener("error", this.handleXHRStateChange);
        xhr.send();
    },

    componentDidMount: function () {
        this.fetchFromServer();
        if (this.props.pollInterval != null) {
            window.setInterval(this.fetchFromServer, this.props.pollInterval);
        }
    },

    handleFormSubmission: function (submission) {

        var data = {
            name: submission.name,
            email: submission.email,
            message: submission.message
        }

        var xhr = new XMLHttpRequest();
        xhr.open("POST", this.props.formPostUrl, true);
        xhr.setRequestHeader("Content-Type", "application/json");
        xhr.addEventListener("load", this.handleXHRStateChange);
        xhr.addEventListener("error", this.handleXHRStateChange);
        xhr.send(JSON.stringify(data));
    },

    render: function () {

        return (
            <section className="body-content">
                <div className="row">
                    <div className="col-xs-5">

                        <Frame title="Contact us: ">
                            <ContactForm onFormSubmit={this.handleFormSubmission} />
                        </Frame>

                        <Frame title="Results">
                            <Result value={this.state.networkState} />
                        </Frame>

                    </div>

                    <div className="col-xs-1"></div>

                    <div className="col-xs-6">

                        <Frame title="Weather:">
                            <Weather />
                        </Frame>

                        <Frame title="Clock: ">
                            <Clock />
                        </Frame>

                        <Frame title="Client Queries: ">
                            <FormTable data={this.state.queries} />
                        </Frame>
                    </div>
                </div>
            </section>
        );
    },

    handleXHRStateChange: function (event) {

        var isPolling = event.target.status === 200;

        if (isPolling) {
            this.updateModel(event.target);
        } else {
            this.updateNetworkState(event.target);
        }
    },

    updateModel: function (response) {
        this.setState({
            queries: this.TryParseJSON(response.responseText)
        });
    },
    updateNetworkState: function (response) {
        this.setState({
            networkState: this.prettyPrintJSON({
                statusCode: response.status,
                response: this.TryParseJSON(response.responseText)
            })
        });
    },
    TryParseJSON: function (object) {
        if (typeof object == "string" && object.length > 0) {
            return JSON.parse(object);
        }
        return object;
    },
    prettyPrintJSON: function (object) {
        if (object == null) {
            return object;
        }
        if (typeof object == "string" && object.length > 0) {
            JSON.parse(object);
        }
        return JSON.stringify(object, null, 2);
    }
});

ReactDOM.render(
    React.createElement(App,
        {
            formPostUrl: window.location.origin + "/contactus/submitform",
            queriesGetUrl: window.location.origin + "/contactus/forms",
            pollInterval: 5000
        },
        null),
    document.getElementById('app')
);