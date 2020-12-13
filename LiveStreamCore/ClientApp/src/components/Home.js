import React, { Component } from 'react';
import { Link } from 'react-router-dom';
export class Home extends Component {
    static displayName = Home.name;

    constructor() {
        super();
        this.state = {
            videos: []
        };
    }
    async componentDidMount() {
        try {
            const response = await fetch('LiveStream/GetMetadata');
            const data = await response.json();
            this.setState({ videos: [...data] });
        } catch (error) {
            console.log(error);
        }
    }
    render () {
        return (
            <div className="App App-header">
                <div className="container">
                    <div className="row">
                        {this.state.videos.map(video =>
                            <div className="col-md-4" key={video.id}>
                                <Link to={`/live-stream/${video.id}`}>
                                    <div className="card border-0">
                                        <img style={{ width: 350, height: 'auto' }} src={video.thumbnail} alt={video.name} />
                                        <div className="card-body">
                                            <p>{video.name}</p>
                                        </div>
                                    </div>
                                </Link>
                            </div>
                        )}
                    </div>
                </div>
            </div>
        );
    }
}
