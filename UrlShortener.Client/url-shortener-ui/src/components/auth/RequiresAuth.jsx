import {Navigate} from "react-router-dom";
import { toast } from "react-toastify";
import { useStore } from "../stores/StoresManager";

export const Auth = ({children, role = null}) => {
    const { userStore } = useStore();

    if (!userStore.isLoggedIn) { 
        return <Navigate to='/login'/>
    }

    if(role) {
        if(userStore.user.role === role) {
            return children;
        } else {
            toast.error('You do not have permission to access this page');
            return <Navigate to='/login'/>
        }
    }

    return children;
}