import React from "react";
import "whatwg-fetch";
import path from "path";

export default class ConversionBox extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            source: "EUR",
            target: "USD",
            amount: 1.0,
            result_currency: null,
            result_amount: null,
            error: ''
        }
    }

    setResult = (result) => {
        this.setState({ result_currency: result.currency, result_amount: result.amount, error: '' });
    }

    setError = (message) => {
        this.setState({ result_currency: null, result_amount: null, error: message });
    }

    handleConvert = (event) => {
        const address = path.join(window.location.pathname, "api/exchange/" +
            this.state.source + "/" + this.state.target + "/" + this.state.amount);
        var set = this.setResult;
        var error = this.setError;

        fetch(address,
            {
                method: "GET",
                headers: {
                    'accept': "application/json",
                    'content-Type': "application/json",
                    'pragma': 'no-cache',
                    'cache-control': 'no-cache'
                }
            }).then(function (res) {
                if (res.ok) {
                    return res.json();
                } else {
                    return res.json()
                        .then(function (err) {
                            console.error(err);
                            throw new Error(err.Message);
                        });
                }
            }).then(function (result) {
                set(result);
            }).catch(function (ex) {
                error(ex.toString());
            });
    }

    handleSource = (event) => {
        this.setState({ source: event.target.value });
    }
    handleAmount = (event) => {
        this.setState({ amount: parseFloat(event.target.value) });
    }
    handleTarget = (event) => {
        this.setState({ target: event.target.value });
    }

    render() {
        return <form>
            <div className="row">
                <div className="col-md-3 col-md-offset-3">
                    <label className="label label-primary label-big">Source currency</label>
                </div>
                <div className="col-md-3">
                    <select id="source" className="form-control" defaultValue={this.state.source} onChange={this.handleSource}>
                        <option value="EUR">Euro</option>
                        <option value="GBP">Pound Sterling</option>
                        <option value="USD">US Dollar</option>
                    </select>
                </div>
            </div>
            <div className="row">
                <div className="col-md-3 col-md-offset-3">
                    <label className="label label-primary label-big">Amount to convert</label>
                </div>
                <div className="col-md-3">
                    <input type="number" id="amount" className="form-control"
                        defaultValue={this.state.amount} value={this.state.value} onChange={this.handleAmount} />
                </div>
            </div>
            <div className="row">
                <div className="col-md-3 col-md-offset-3">
                    <label className="label label-primary label-big">Target currency</label>
                </div>
                <div className="col-md-3">
                    <select id="target" className="form-control" defaultValue={this.state.target} onChange={this.handleTarget}>
                        <option value="EUR">Euro</option>
                        <option value="GBP">Pound Sterling</option>
                        <option value="USD">US Dollar</option>
                    </select>
                </div>
            </div>
            <br />
            <div className="row">
                <div className="col-md-4 col-md-offset-4">
                    <button type="button" onClick={this.handleConvert} className="btn btn-spacing btn-primary btn-block">Convert</button>
                </div>
            </div>
            <div className="row">
                <br />
                <div className="col-md-4 col-md-offset-4 text-center">
                    <div className="error">{this.state.error}</div>
                    <strong>{this.state.result_currency} {this.state.result_amount}</strong>
                </div>
            </div>
        </form>;
    }
}
