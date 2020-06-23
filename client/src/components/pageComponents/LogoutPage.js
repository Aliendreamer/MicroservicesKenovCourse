import React, { useContext } from "react";
import { Redirect } from "react-router-dom";
import { Context as AuthContext } from "../../contexts/authContext";
const LogoutPage = () => {
	const { state: { isLogged }, logOutUser } = useContext(AuthContext);
	logOutUser(!isLogged);
	return (<Redirect to={{ pathname: "/" }} />);
};

export default LogoutPage;
