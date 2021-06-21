const initialState = {
    accessToken = '',
    refreshToken = ''
}

export const ActionTypes = {
    LOGIN: 'LOGIN',
    REGISTER: 'REGISTER',
    SET_TOKENS: 'SET_TOKENS',
    LOGOUT: 'LOGOUT',
}

export const ActionCreators = {
    setTokens: payload => ({ type: ActionTypes.SET_TOKENS, payload }),
    login: payload => ({ type: ActionTypes.LOGIN, payload }),
    register: payload => ({ type: ActionTypes.REGISTER, payload }),
    logout: payload => ({ type: ActionTypes.LOGOUT, payload }),
}

export default function AuthReducer(state = initialState, action) {
    switch (action.type) {
        case ActionTypes.LOGIN:
            
        case ActionTypes.REGISTER:

        case ActionTypes.SET_TOKENS:

        case ActionTypes.LOGOUT:

        default:
            return state;
    }
}