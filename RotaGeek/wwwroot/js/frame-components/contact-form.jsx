var ContactForm = React.createClass({

    getInitialState: function () {
        return {
            name: '',
            email: '',
            message: ''
        }
    },

    handleNameChange: function (e) {
        this.setState({ name: e.target.value });
    },
    handleEmailChange: function (e) {
        this.setState({ email: e.target.value });
    },
    handleMessageChange: function (e) {
        this.setState({ message: e.target.value });
    },

    handleSubmit: function(e) {

        e.preventDefault();

        var name = this.state.name.trim(),
            email = this.state.email.trim(),
            message = this.state.message.trim();

        this.props.onFormSubmit(this.state);

        this.clearState();
    },

    clearState: function() {
        this.setState({ name: '', email: '', message: '' });
    },

    IsEmpty: function(model) {
        return model == null || value.length === 0;
    },

    render: function () {
        return (
            <table className="table table-striped">
                <thead>
                <tr>
                    <th>Field</th>
                    <th>Value</th>
                </tr>
                </thead>
                <tbody>
                <tr>
                    <td>Name:</td>
                    <td><input type="text" className="form-control" value={this.state.name} onChange={this.handleNameChange} /></td>
                </tr>
                <tr>
                    <td>Email Address:</td>
                    <td><input type="text" className="form-control" value={this.state.email} onChange={this.handleEmailChange} /></td>
                </tr>
                <tr>
                    <td>Message:</td>
                    <td><input type="text" className="form-control" value={this.state.message} onChange={this.handleMessageChange} /></td>
                </tr>
                <tr>
                    <td>Submit:</td>
                    <td><input type="submit" value="Post" className="form-control" onClick={this.handleSubmit} /></td>
                </tr>
                </tbody>
            </table>
        );
    }
});
