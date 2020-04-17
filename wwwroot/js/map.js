function initMap() {
    // Create the main viewer.
    var viewer = new ROS2D.Viewer({
        divID : 'map',
        width : 700,
        height : 700
    });
    
    var gridClientNav = new NAV2D.OccupancyGridClientNav({
        ros : ros,
        rootObject : viewer.scene,
        viewer : viewer,
        withOrientation : true,
        serverName : '/move_base',
        image : 'img/pioneerlxmodel.png'
    });

    var poseTopic = new ROSLIB.Topic({
        ros: ros,
        name: '/amcl_pose',
        messageType: 'geometry_msgs/PoseWithCovarianceStamped'
    });
    poseTopic.subscribe(function (pose) {
        console.log("x: " + pose.pose.pose.position.x + "y: " + pose.pose.pose.position.y);
    });

    var mapTopic = new ROSLIB.Topic({
        ros: ros,
        name: '/map',
        messageType: 'geometry_msgs/PoseWithCovarianceStamped'
    });
    var staticMap;
    var flag = true;
    mapTopic.subscribe(function (mapT) {
        staticMap = mapT.data;
    });
    flag = false;

    
    // var getStaticMapClient = new ROSLIB.Service({
    //     ros : ros,
    //     name : '/static_map',
    //     serviceType : 'nav_msgs/GetMap'
    // });

    // var request = new ROSLIB.ServiceRequest({
    // });
    // var flag = true;
    // getStaticMapClient.callService(request, function(result) {

       
    // });
    // flag = false;


    const canvas = document.querySelector('#map canvas');
    function onClick(event, x, y) {
        console.log(getCursorPosition(event));
    };
    canvas.addEventListener('click', (e) => onClick(e), false);
    
    // Function for getting cursor position from canvas click
    function getCursorPosition(event) {
        var x;
        var y;
        if(event.pageX != undefined && event.pageY != undefined) {
            x = event.pageX;
            y = event.pageY;
        } else {
            x = event.clientX + document.body.scrollLeft + document.documentElement.scrollLeft
            y = event.clientY + document.body.scrollTop + document.documentElement.scrollTop
        };
        x -= canvas.offsetLeft;
        y -= canvas.offsetTop;
        return [x, y];
    };

    
}