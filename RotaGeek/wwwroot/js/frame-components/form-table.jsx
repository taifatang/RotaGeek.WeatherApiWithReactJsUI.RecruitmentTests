var FormTable = React.createClass({

    componentWillMount: function() {
       
    },

    render: function () {
        //TODO: Do not use i an key
        var queries = this.props.data.map(function (query, i) {
            return (
                <FormEntry key={i} name={query.name} email={query.email} message={query.message} />
            );
        });

        return (
            <table className="table table-striped">
                <thead>
                <tr>
                    <th>Name</th>
                    <th>Message</th>
                </tr>
                </thead>
                <tbody>
                {queries}
                </tbody>
            </table>
        );
    }
});
