import React, { Component } from 'react';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true, userInput: '' };
    }

    componentDidMount() {
        const userInput = prompt('Enter zipcode or City name to check weather status');
        if (userInput !== null) {
            //this.setState({userInput: userInput})
            this.populateWeatherData(userInput);
            console.log("in", userInput)
        }
    }

    static renderForecastsTable(forecasts) {
        return (
            <>
                <div>
                    Your location name: {forecasts.locationName}
                    <p>Should I go outside? {forecasts.weatherDescriptions[0] === 'Rain' ? 'No' : 'Yes'} </p>
                    <p>Should I wear sunscreen? {forecasts.uvIndex > 3 ? 'Yes' : 'No'}</p>
                    <p>Can I fly my kite? {forecasts.weatherDescriptions[0] !== 'Rain' && forecasts.windSpeed > 15 ? 'Yes' : 'No'}</p>
                </div>
                <Popup trigger={<button>Trigger</button>} position="top left">
                    {close => (
                        <div>
                            Content here
                            <a className="close" onClick={close}>
                                &times;
                            </a>
                        </div>
                    )}
                </Popup>
            </>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading... </em></p>
            : App.renderForecastsTable(this.state.forecasts);

        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                {contents}
            </div>
        );
    }

    async populateWeatherData(userInput) {
        const response = await fetch(`weatherforecast/${userInput}`);
        const data = await response.json();
        console.log(data);
        this.setState({ forecasts: data, loading: false, userInput: '' });
    }
}
