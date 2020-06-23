/* eslint-disable react/jsx-closing-tag-location */
import React, { useEffect, useState, useContext } from "react";
import { Context as AuthContext } from "../../contexts/authContext";
import { Collapse, Navbar, NavbarToggler, NavbarBrand, Nav, NavItem, NavLink } from "reactstrap";
import { Link } from "react-router-dom";

const BasePage = ({ children }) => {
	const { state: { isLogged }, logOutUser } = useContext(AuthContext);
	const [isOpen, setIsOpen] = useState(false);

	const toggle = () => setIsOpen(!isOpen);
	useEffect(() => {

	}, [isLogged, isOpen]);
	return (
		<>
			<Navbar className="navbar navbar-expand-lg navbar-dark bg-dark">
				<NavbarBrand href="/">Library</NavbarBrand>
				<NavbarToggler onClick={toggle} />
				<Collapse isOpen={isOpen} navbar>
					<Nav className="mr-auto" navbar>
						{isLogged
							? <>
								<NavItem>
									<Link to="/account" replace={true}>Account</Link>
								</NavItem>
								<NavItem>
									<Link to="/">BookList</Link>
								</NavItem>
								<NavItem>
									<Link to="/">Authors</Link>
								</NavItem>
								<NavItem>
									<Link to="/login">Favorites</Link>
								</NavItem>
								<NavItem>
									<Link to="/logout">Logout</Link>
								</NavItem>
							</>
							: <>
								<NavItem>
									<Link to="/login">Login</Link>
								</NavItem>
								<NavItem>
									<Link to="/register">Register</Link>
								</NavItem>
							</>}
					</Nav>
				</Collapse>
			</Navbar>
			{children}
			<div className="container">
				<Navbar className="navbar navbar-expand-lg fixed-bottom navbar-dark bg-dark" />
			</div>
		</>
	);
};

export default BasePage;
