var FormEntry = React.createClass({

    render: function () {
        return (
            <tr>
                <td title={this.props.email}>{this.props.name}</td>
                <td>{this.props.message}</td>
            </tr>
        );
    }
})