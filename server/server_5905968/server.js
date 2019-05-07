var port = process.env.PORT || 3000;
var io = require('socket.io')(port);


var RandomNum = Math.floor(Math.random() * 100);

console.log("server started on port " + port);

console.log(RandomNum);

io.on("connection",function(socket){

    console.log("client connect");
    socket.emit("open");

    socket.on("Check",function(data){
        
        

        //console.log(playerNum);
        
        //data = data.mynum;
        //delete data.mynum;
        
        if(data.mynum == RandomNum)
        {
            var result = {text:"Win"}
        }
        else if(data.mynum < RandomNum)
        {
            var result = {text:"Less"}
        }
        else if(data.mynum > RandomNum)
        {
            var result = {text:"Most"}
        }
        
        socket.emit("getValue",result);
        
    });
});