import React, { useContext, useEffect } from "react";
import { Context as AuthContext } from "../../contexts/authContext";
import AnonymousHome from "./AnonymousHome";
import HomeAuthenticated from "./HomeAuthenticated";
import { Container } from "reactstrap";
const HomePage = () => {
	const { state: { isLogged } } = useContext(AuthContext);
	useEffect(() => {

	}, [isLogged]);
	return (
		<>
			<Container style={{ backgroundColor: "lightblue", width: "100%", marginTop: "100px" }}>
				{isLogged ? <HomeAuthenticated /> : <AnonymousHome />}
			</Container>
		</>
	);
};

export default HomePage;
