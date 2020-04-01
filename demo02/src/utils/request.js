//import {fetch} from 'whatwg-fetch'
import axios from "axios";
// import qs from 'qs'
// import { notification } from "ant-design-vue";

// function request(config){//modulename, funname, para, success, fail) {
//     fetch("http://localhost:50618/api/" + config.modulename + "/" + config.funname + "", {
//         method: "post",
//         headers: {
//             "Accept": "application/json, text/plain, */*",
//             "Content-Type": "application/json"
//         },
//         body: JSON.stringify(config.para),
//         mode: 'cors',
//         //credentials: 'include'
//     }).then(
//         (res) => { return res.json() }
//     ).then(
//         (res)=>{config.success(res)}
//     ).catch(
//         (ex)=>{config.fail(ex)}
//     )
// }
function request(config) {

    axios({
        baseURL: 'http://localhost:63109/api/',
        url: '/' + config.modulename + '/' + config.funname,
        headers: {
            "Accept": "application/json, text/plain, */*",
            "Content-Type": "application/json"
        },
        method: 'post',
        data: config.para
    }).then(
        res=>{config.success(res)}
    ).catch(
        err=>config.fail(err)
    )

    return axios.post
}

export default request;
