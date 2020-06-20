import React, { useContext } from "react";
import { Context as AuthContext } from "../../contexts/authContext";
import AnonymousHome from "./AnonymousHome";
import { Container } from "reactstrap";
const HomePage = () => {
	const { state: isLogged } = useContext(AuthContext);

	return (
		<>
			<Container style={{ backgroundColor: "lightblue", width: "100%", marginTop: "100px" }}>
				{isLogged ? <AnonymousHome /> : null}
			</Container>
		</>
	);
};

export default HomePage;
