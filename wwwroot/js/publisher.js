/*Writes websocket server status to console log*/
function initPublisher() {
    ros.on('connection', function() {
        console.log('Connected to websocket server.');
    });
    
    ros.on('error', function(error) {
        console.log('Error connecting to websocket server: ', error);
    });
    
    ros.on('close', function() {
        console.log('Connection to websocket server closed.');
    });
}

/*Called by 'start robot' and 'stop robot' buttons*/
function SetBehaviour(val) {
    var cmdBehaviour = new ROSLIB.Topic({
        ros: ros,
        name: '/cyborg_commander/behaviour_state',
        messageType: 'std_msgs/Bool'
    });

    var behaviourVal = new ROSLIB.Message({
        data: val
    });
    cmdBehaviour.publish(behaviourVal);
}


// async.retry({times: 15, interval: 200}, setBehaviour, function(val, err, result) {
// });


// function rosTopics() {
//     var ros = new ROSLIB.Ros({
//         url: 'ws://localhost:9090'
//     })
//     var cmdVel = new ROSLIB.Topic({
//         ros: ros,
//         name: '/Cmd_vel',
//         messageType: 'geometry_msgs/Twist'
//     });

//     var twist = new ROSLIB.Message({
//         linear: {
//             x: 0.1,
//             y: 0.2,
//             z: 0.3
//         },
//         angular: {
//             x: -0.1,
//             y: -0.2,
//             z: -0.3
//         }
//     });
//     cmdVel.publish(twist);

//     ROSLIB.Ros.prototype.getTopics = function(callback) {
//         var topicsClient = new ROSLIB.Service({
//             ros: ros,
//             name: '/rosapi/topics',
//             serviceType: 'rosapi/Topics'
//         });

//         var request = new ROSLIB.ServiceRequest();

//         topicsClient.callService(request, function(result) {
//             callback(result.topics);
//         });
//     };
//     console.log(ROSLIB.Ros.prototype.getTopics());
// }
