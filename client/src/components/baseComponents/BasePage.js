/* eslint-disable react/jsx-closing-tag-location */
import React, { useEffect, useState, useContext } from "react";
import { Context as AuthContext } from "../../contexts/authContext";
import { Collapse, Navbar, NavbarToggler, NavbarBrand, Nav, NavItem, NavLink } from "reactstrap";

const BasePage = ({ children }) => {
	const { state: { isLogged } } = useContext(AuthContext);
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
									<NavLink to="/account" replace={true}>Account</NavLink>
								</NavItem>
								<NavItem>
									<NavLink href="/">BookList</NavLink>
								</NavItem>
								<NavItem>
									<NavLink href="/">Authors</NavLink>
								</NavItem>
								<NavItem>
									<NavLink href="/login">Favorites</NavLink>
								</NavItem>
								<NavItem>
									<NavLink href="/logout">logout</NavLink>
								</NavItem>
							</>
							: <>
								<NavItem>
									<NavLink href="/login">Login</NavLink>
								</NavItem>
								<NavItem>
									<NavLink href="/register">Register</NavLink>
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
