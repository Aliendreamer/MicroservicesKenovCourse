import createDataContext from "./createDataContext";

const authReducer = (state, action) => {
	switch (action.type) {
		case "login":
			return {
				...state,
				count: action.payload
			};
		case "logOut":
			return {
				...state,
				count: action.payload
			};
		case "register":
			return {
				...state,
				count: 0
			};
		case "deleteProfile":
			return {
				...state,
				count: 0
			};
		default:
			return state;
	}
};

const increment = dispatch => count => {
	dispatch({ type: "increment", payload: count });
};

const decrement = dispatch => count => {
	dispatch({ type: "decrement", payload: count });
};

export const { Context, Provider } = createDataContext(authReducer,
	{ increment, decrement },
	{ isLogged: false, isAdmin: false }
);
