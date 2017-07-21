var App = React.createClass({
    render: function () {
        return (
            <section className="body-content">
                <div className="row">
                    <div className="col-xs-5">

                        <Frame title="Contact us: ">
                            <ContactForm />
                        </Frame>
                        <Frame title="Results">
                            <Result />
                        </Frame>

                    </div>

                    <div className="col-xs-1"></div>

                    <div className="col-xs-6">

                        <Frame title="Weather: ">
                            <a className="btn btn-default btn-default-override">Get Weather</a>
                        </Frame>
                        <Frame title="Clock: ">
                            <a className="btn btn-default btn-default-override">Get Time</a>
                        </Frame>
                        <Frame title="Queries: ">
                            <Query url="/contactus/forms" pollInterval="200"/>
                        </Frame>

                    </div>
                </div>
            </section>
        );
    }
});

ReactDOM.render(
    React.createElement(App, null),
    document.getElementById('app')
);