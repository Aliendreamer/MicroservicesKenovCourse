import createDataContext from "./createDataContext";

const authReducer = (state, action) => {
	switch (action.type) {
		case "login":
			return {
				...state,
				isLogged: action.payload
			};
		case "logOut":
			return {
				...state,
				isLogged: false
			};
		default:
			return state;
	}
};

const loginUser = dispatch => isLogged => {
	dispatch({ type: "login", payload: isLogged });
};

const logOutUser = dispatch => isLogged => {
	dispatch({ type: "logOut", payload: isLogged });
};
export const { Context, Provider } = createDataContext(authReducer,
	{ loginUser, logOutUser },
	{ isLogged: false, isAdmin: false }
);
