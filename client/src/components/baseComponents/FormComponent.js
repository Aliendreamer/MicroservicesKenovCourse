/* eslint-disable react/jsx-closing-tag-location */
import React from "react";
import { useForm } from "react-hook-form";
import { authInstanceActions } from "../../helpers/axiosFactory";
import { Form, FormGroup, Label, Input, FormFeedback, Button, Jumbotron, Container } from "reactstrap";

const FormComponent = ({ isLogin }) => {
	const { register, handleSubmit, errors } = useForm();
	const onSubmit = data => {
		debugger;
		authInstanceActions("POST", "users/register", data);
	};

	return (
		<Jumbotron fluid>
			<Container fluid>
				<Form onSubmit={handleSubmit(onSubmit)}>
					<FormGroup>
						<Label for="FirstName">FirstName</Label>
						<Input name="FirstName" placeholder="FirstName" id="FirstName" ref={register({ required: true })} />
						{errors.FirstName && <FormFeedback>FirstName is required</FormFeedback>}
					</FormGroup>
					{!isLogin
						? <>
							<FormGroup>
								<Label for="LastName">LastName</Label>
								<Input name="LastName" placeholder="LastName" id="LastName" ref={register({ required: true })} />
								{errors.LastName && <FormFeedback>LastName is required</FormFeedback>}
							</FormGroup>
							<FormGroup>
								<Label for="UserName">LastName</Label>
								<Input name="UserName" placeholder="UserName" id="LastName" ref={register({ required: true })} />
								{errors.UserName && <FormFeedback>UserName is required</FormFeedback>}
							</FormGroup>
						</>
						: null}
					<FormGroup>
						<Label for="Password">Password</Label>
						<Input name="Password" placeholder="Password" id="Password" ref={register({ required: true })} />
						{errors.UserName && <FormFeedback>password is required</FormFeedback>}
					</FormGroup>
					<Button type="submit">{isLogin ? "Login" : "Register"}</Button>
				</Form>
			</Container>
		</Jumbotron>
	);
};
export default FormComponent;
