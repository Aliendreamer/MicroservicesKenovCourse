/* eslint-disable react/jsx-closing-tag-location */
import React, { useEffect, useState } from "react";
import { Context as AuthContext } from "../../contexts/authContext";
const BasePage = ({ children }) => {
	const { state: isLogged } = useState(AuthContext);
	useEffect(() => {

	}, [isLogged]);
	return (
		<>
			<nav className="navbar navbar-expand-lg sticky-top navbar-dark bg-dark">
				<button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
					<span className="navbar-toggler-icon" />
				</button>
				<div className="collapse navbar-collapse" id="navbarNavAltMarkup">
					<div className="navbar-nav">
						<a className="nav-item nav-link active" href="#">Home <span className="sr-only">(current)</span></a>
						{isLogged
							? <div>
								<a className="nav-item nav-link" href="#">Features</a>
								<a className="nav-item nav-link" href="#">Pricing</a>
								<a className="nav-item nav-link disabled" href="#" tabIndex="-1" aria-disabled="true">Disabled</a>
							</div>
						 : null}
					</div>
				</div>
			</nav>
			{children}
			<div className="container">
				<nav className="navbar navbar-expand-lg fixed-bottom navbar-dark bg-dark" />
			</div>
		</>
	);
};

export default BasePage;
