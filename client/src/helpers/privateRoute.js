import React, { useContext } from "react";
import { Route, Redirect } from "react-router-dom";
import { Context as AuthContext } from "../contexts/authContext";

const PrivateRoute = ({ children, ...rest }) => {
	const { state: isLogged } = useContext(AuthContext);
	return (
		<Route
			{...rest}
			render={({ location }) =>
				isLogged ? (
					children
				) : (
					<Redirect
						to={{
							pathname: "/login",
							state: { from: location }
						}}
					/>
				)}
		/>
	);
};
export default PrivateRoute;
