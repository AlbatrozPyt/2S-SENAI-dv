import { Navigate } from "react-router-dom";

export const PrivateRoute = ({ children, redirectTo = "/" }) => {
    const isAutenticated = localStorage.getItem("token") !== null;

    return isAutenticated ? children : <Navigate to={redirectTo}/>
};
