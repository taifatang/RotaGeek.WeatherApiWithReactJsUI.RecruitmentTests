var Frame = React.createClass({

    render: function () {
        return (
            <div className="row">
                <div className="panel-group">
                    <div className="panel panel-default panel-default-override">
                        <div className="panel-heading">{this.props.title}</div>
                        <div className="panel-body">
                            { this.props.children }
                        </div>
                    </div>
                </div>
            </div>
        );
    }
})