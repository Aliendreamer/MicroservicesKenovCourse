import React from "react";
import { Card, CardImg, CardText, CardBody, CardTitle, CardSubtitle, Button } from "reactstrap";

const HomeLoggedPage = () => {
	return (
		<div>
			<Card>
				<CardImg top width="100%" height="50%" src="https://images.unsplash.com/photo-1494548162494-384bba4ab999?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=800&q=80" alt="Card image cap" />
				<CardBody>
					<CardTitle>Welcome</CardTitle>
					<CardSubtitle>Card subtitle</CardSubtitle>
					<CardText>what will you want ot do next</CardText>
					<Button>Button</Button>
				</CardBody>
			</Card>
		</div>
	);
};

export default HomeLoggedPage;
