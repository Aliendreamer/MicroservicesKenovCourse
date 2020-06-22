/* eslint-disable react/jsx-closing-tag-location */
import React, { useContext, useState } from "react";
import { useForm, Controller, ErrorMessage } from "react-hook-form";
import { authInstanceActions } from "../../helpers/axiosFactory";
import { Form, FormGroup, Label, Input, Button, Jumbotron, FormText, Container } from "reactstrap";
import { useHistory } from "react-router-dom";
import { Context as AuthContext } from "../../contexts/authContext";

const FormComponent = ({ isLogin }) => {
	const { errors, control, handleSubmit } = useForm();
	const { loginUser } = useContext(AuthContext);
	const [error, setError] = useState(null);
	const history = useHistory();
	const onSubmit = async (data) => {
		const path = !isLogin ? "users/register" : "users/authenticate";
		const response = await authInstanceActions("POST", path, data);
		if (response.data) {
			localStorage.setItem("jwtToken", response.data.jwtToken);
			loginUser(true);
			history.push("/");
			// var retrievedObject = localStorage.getItem('testObject');
		}
		if (response.error) {
			setError("Pls try again or later if error persists ");
			setTimeout(() => setError(null), 3000);
		}
	};
	return (
		<Jumbotron fluid>
			<Container fluid>
				<Form onSubmit={handleSubmit(onSubmit)}>
					<FormGroup>
						<Label for="UserName">UserName</Label>
						<Controller
							as={Input}
							name="UserName"
							placeholder="UserName"
							id="UserName"
							control={control}
							rules={{ required: "This is required" }}
						/>
						<ErrorMessage errors={errors} name="UserName" as="p" />
					</FormGroup>
					{!isLogin
						? <>
							<FormGroup>
								<Label for="FirstName">FirstName</Label>
								<Controller
									as={Input}
									name="FirstName" placeholder="FirstName"
									id="FirstName"
									control={control}
									rules={{ required: "This is required" }}
								/>
								<ErrorMessage errors={errors} name="FirstName" as="p" />
							</FormGroup>
							<FormGroup>
								<Label for="LastName">LastName</Label>
								<Controller
									as={Input}
									name="LastName"
									placeholder="LastName"
									id="LastName"
									control={control}
									rules={{ required: "This is required" }}
								/>
								<ErrorMessage errors={errors} name="LastName" as="p" />
							</FormGroup>
						</>
						: null}
					<FormGroup>
						<Label for="Password">Password</Label>
						<Controller
							as={Input}
							name="Password"
							placeholder="Password"
							id="Password"
							control={control}
							rules={{ required: "This is required" }}
						/>
						<ErrorMessage errors={errors} name="UserName" as="p" />
					</FormGroup>
					<Button type="submit">{isLogin ? "Login" : "Register"}</Button>
				</Form>
				{error && <FormText color="danger">{error}</FormText>}
				{!isLogin && <Button color="link" onClick={() => history.push("/login")}>Already have account?</Button>}
			</Container>
		</Jumbotron>
	);
};
export default FormComponent;
