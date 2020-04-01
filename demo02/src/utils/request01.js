import axios from "axios";
var delData = function(id){
   return axios.delete(`http://localhost:63109/api/Crud/Delete?id=${id}`)
}
var queryData = function(id){
   return axios.get("http://localhost:63109/api/Crud/Query")
}
var updateData = function(para){
   return axios.put("http://localhost:63109/api/Crud/Update",para)
}
var addData = function(para){
    return axios.post("http://localhost:63109/api/Crud/Add",para)
}
var getDetailData = function(id){
   return axios.put(`http://localhost:63109/api/Crud/Detail?id=${id}`)
}
export{initData,delData,queryData,updateData,getDetailData,addData}