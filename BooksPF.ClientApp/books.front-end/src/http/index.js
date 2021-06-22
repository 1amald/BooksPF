import axios from "axios";

export const API_URL = 'https://localhost:44376/api'

export const api = axios.create({
    baseURL: API_URL
})

api.interceptors.request.use(function(config){
    config.headers['Content-type'] = 'application/json';
    config.headers['Authorization'] = 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImlhbWFsZCIsInN1YiI6IjYwY2JiOTcxYmM2NDQ2MDc4N2Y5MTdkYyIsImV4cCI6MTYyNDI2NDEwNiwiaXNzIjoic2VydmVyIiwiYXVkIjoiY2xpZW50In0.qPSzAmHVPKsNWMwacIutuVynlI49f2G2A2C8-hAgvgM';
    return config;
})