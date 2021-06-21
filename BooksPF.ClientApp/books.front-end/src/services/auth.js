import { api } from "../http";
import { ActionCreators } from "../redux/authReducer";

export const Login = async (dispatch, login, password) => {
    try {
        const { data } = await api.post('user/login',{params: {login: login, password: password}});
        dispatch(ActionCreators.login(data));
    } catch (err){
        console.log(err.message);
    }
}

export const Register = async (dispatch, login, password, confirmPassword) => {
    try {
        const { data } = await api.post('user/register',{params: {login: login, password: password,confirmPassword: confirmPassword}});
        dispatch(ActionCreators.register(data));
    } catch (err){
        console.log(err.message);
    }
}
