const express=require('express');
const app=express();
const port=3000;
app.get('/',(req,res)=>{
    let today=new Date();
    let time=today.getHours()+":"+today.getMinutes()+":"+today.getSeconds();

    let message=`Response From MicroService  , current time is ${time}`;
    res.send(message);
});
app.listen(port,()=>{
    console.log("Microservice One is running");
});