/* eslint-disable react/jsx-closing-tag-location */
import React, { useEffect, useContext } from "react";
import { Link, NavLink } from "react-router-dom";
import { Context as AuthContext } from "../../contexts/authContext";
const BasePage = ({ children }) => {
	const { state: { isLogged } } = useContext(AuthContext);
	useEffect(() => {

	}, [isLogged]);
	return (
		<>
			<nav className="navbar navbar-expand-lg navbar-dark bg-dark">
				<button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo01" aria-controls="navbarTogglerDemo01" aria-expanded="false" aria-label="Toggle navigation">
					<span className="navbar-toggler-icon" />
				</button>
				<div className="collapse navbar-collapse" id="navbarTogglerDemo01">
					<a className="navbar-brand" href="/"> Library</a>
					<ul className="navbar-nav mr-auto mt-2 mt-lg-0">
						<li className="nav-item active">
							<Link to="/" replace={true}>Home</Link>
						</li>
						{isLogged
							? <>
								<li className="nav-item">
									<Link to="/account" replace={true}>Account</Link>
								</li>
								<li className="nav-item">
									<a className="nav-link" href="#" tabIndex="-1" aria-disabled="true">BookList</a>
								</li>
								<li className="nav-item">
									<a className="nav-link" href="#" tabIndex="-1" aria-disabled="true">Authors</a>
								</li>
								<li className="nav-item">
									<a className="nav-link" href="#" tabIndex="-1" aria-disabled="true">Favorites</a>
								</li>
							</>
							: <>
								<li className="nav-item">
									<NavLink exact={true} activeClassName='is-active' to='/login'>Login</NavLink>
								</li>
								<li className="nav-item">
									<NavLink exact={true} activeClassName='is-active' to='/register'>Register</NavLink>
								</li>
							</>}
					</ul>
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
