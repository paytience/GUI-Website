var staticMap;
var canvasWidth = 700;
var canvasHeight = 700;
var mapWidth;
var widthRatio;
var heightRatio;
var mapClick = false;


function initMap() {
    // Create the main viewer.
    var viewer = new ROS2D.Viewer({
        divID : 'map',
        width : canvasWidth,
        height : canvasHeight
    });

    var gridClientNav = new NAV2D.OccupancyGridClientNav({
        ros : ros,
        rootObject : viewer.scene,
        viewer : viewer,
        withOrientation : true,
        serverName : '/move_base',
        image : 'img/pioneerlxmodel.png'
    });

    var mapTopic = new ROSLIB.Topic({
        ros: ros,
        name: '/map',
        messageType: 'nav_msgs/OccupancyGrid'
    });

    mapTopic.subscribe(function (mapT) {
        mapTopic.unsubscribe();
        staticMap = mapT.data;
        mapWidth = mapT.info.width;
        widthRatio = mapT.info.width / canvasWidth;
        heightRatio = mapT.info.height / canvasHeight;
    });
    
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

    
    // const canvas = document.querySelector('#map canvas');
    // // function onClick(event, x, y) {
    // //     console.log(getCursorPosition(event));
    // // };
    // function onClick(event, x, y) {
    //     getCursorPosition(event);
    // };
    
    // canvas.addEventListener('click', (e) => onClick(e), false);
    
    // // Function for getting cursor position from canvas click
    // function getCursorPosition(event) {
    //     var x;
    //     var y;
    //     if(event.pageX != undefined && event.pageY != undefined) {
    //         x = event.pageX;
    //         y = event.pageY;
    //     } else {
    //         x = event.clientX + document.body.scrollLeft + document.documentElement.scrollLeft
    //         y = event.clientY + document.body.scrollTop + document.documentElement.scrollTop
    //     };
    //     x -= canvas.offsetLeft;
    //     y -= canvas.offsetTop;

    //     x = Math.round(x * widthRatio);
    //     y = Math.round(y * heightRatio);
    //     console.log("x: ")
    //     var num = (x*2528) + y;
    //     console.log(staticMap[num]);
    //     return [x, y];
    // };
}