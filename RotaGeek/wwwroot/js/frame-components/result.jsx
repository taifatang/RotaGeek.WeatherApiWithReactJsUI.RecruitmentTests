var Result = React.createClass({

    render: function () {
        return (
            <div className="tab-content">
                <pre>{this.props.result || "Hello!"}</pre>
            </div>
        );
    }
})