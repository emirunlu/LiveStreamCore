import React, { Component } from 'react';
import 'video.js/dist/video-js.css';
import { Replay } from 'vimond-replay';
import 'vimond-replay/index.css';
import CompoundVideoStreamer from 'vimond-replay/video-streamer/compound';
const replayOptions = {
    videoStreamer: {
        hlsjs: {
            customConfiguration: {
                capLevelToPlayerSize: true,
                maxBufferLength: 120
            }
        },
        shaka: {
            customConfiguration: {
                streaming: {
                    bufferingGoal: 120
                }
            }
        }
    }
};

export class LiveStream extends Component { 
    constructor(props) {
        super(props);
        this.state = {  
            videoId: this.props.match.params.id,
            videoData: {}
        };  
    }

    async componentDidMount() {
        try {   
            const res = await fetch(`LiveStream/GetMetadata/${this.state.videoId}`);
            const data = await res.json();
            this.setState({ videoData: data });
        } catch (error) {
            console.log(error);
        }
    }
    
    componentWillUnmount() {        
        if (this.player) {
            this.player.dispose()
        }
    }
    render() {
        return (
            <div className="App">
                <header className="App-header">
                    <h2>{this.state.videoData.name}</h2>
                    <Replay
                        source={this.state.videoData.src}
                        options={replayOptions}>
                        <CompoundVideoStreamer />
                    </Replay>
                    <h3>{this.state.videoData.description}</h3>
                    <h3>{this.state.videoData.username}</h3>
                </header>
            </div>  
        )
    }
}   
