var Clock = React.createClass({

    getInitialiseState: function() {
        return {
            date: "",
            time: "",
        }
    },
    componentWillMount: function () {
        this.drawClock();
    },
    componentDidMount: function () {
        window.setInterval(this.drawClock, 1000);
    },

    drawClock: function () {
        var dateTime = new Date();
        this.setState({
            date: dateTime.toDateString(),
            time: dateTime.toLocaleTimeString()
        });
    },

    render: function() {
        return (<div>
            {this.state.date} : {this.state.time}
        </div>);
    }
})