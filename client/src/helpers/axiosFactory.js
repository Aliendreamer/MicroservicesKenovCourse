import axios from "axios";
const authInstance = axios.create({
	baseURL: process.env.REACT_APP_BASE_AUTH_URL,
	responseType: "json",
	timeout: 30000
});
const apiInstance = axios.create({
	baseURL: process.env.REACT_APP_BASE_URL,
	responseType: "json",
	timeout: 30000
});
// TODO: find time to refactor this to be generic  once I have enough done to defend the project
// No need for 2 3 or more instances and repeated code for them
export const authInstanceActions = async (method, url, data) => {
	try {
		let response;
		switch (method) {
			case "GET":
				response = await authInstance.get(url, data);
				break;
			case "POST":
				response = await authInstance.post(url, data);
				break;
			default:
				break;
		}
		return { data: response.data, error: null };
	} catch (error) {
		return { data: null, error: "RequestError" };
	}
};

export const useApiInstance = async (method, url, data) => {
	try {
		let response;
		switch (method) {
			case "GET":
				response = await apiInstance.get(url, data);
				break;
			case "Post":
				response = await apiInstance.get(url, data);
				break;
			default:
				break;
		}
		return { data: response.data, error: null };
	} catch (error) {
		return { data: null, error: "RequestError" };
	}
};
