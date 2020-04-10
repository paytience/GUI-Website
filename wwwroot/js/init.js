var ros;
function init() {
    ros = new ROSLIB.Ros({
        url: 'ws://localhost:9090'
    });
    initPublisher();
    initDisplayer();
    initMap();
}