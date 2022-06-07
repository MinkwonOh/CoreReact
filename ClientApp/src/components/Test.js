import React, { Component } from 'react';

export class Test extends Component {
    static displayName = Test.name;

    constructor(props) {
        super(props);
        this.state = { testArray: [], loading: true };
    }

    componentDidMount() {
        this.gettingData();
    }

    static renderTestTable(testArray) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                    </tr>
                </thead>
                <tbody>
                    {testArray.map(array =>
                        <tr key={array.date}>
                            <td>{array.date}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
        ? <p><em>Loading...</em></p>
            : Test.renderTestTable(this.state.testArray);

        return (
            <div>
                <h1 id="tabelLabel">Test Array</h1>
                <p>서버값 가져오기</p>
                {contents}
            </div>
        );
    }

    async gettingData() {
        const response = await fetch('test'); // error
        const data = await response.json();
        const responseDebug = await fetch('test');
        this.setState({testArray: data, loading: false});
    }

}