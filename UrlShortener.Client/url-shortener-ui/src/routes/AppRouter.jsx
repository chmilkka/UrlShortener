import React from 'react';
import { Navigate, Route, Routes } from 'react-router-dom';
import LoginPage from '../pages/LoginPage';
import RegisterPage from '../pages/RegisterPage';
import NotFoundPage from '../pages/NotFoundPage';
import AboutPage from '../pages/AboutPage';
import ShortUrlsTablePage from '../pages/ShortUrlsTablePage';
import { useStore } from '../stores/StoresManager';

const AllRoutes = () => {
    return (
        <Routes>
            <Route index replace element={<Navigate to="/urls"/>}/>
            <Route path ="/login" element={<LoginPage/>}/>
            <Route path ="/logout" element={<Logout/>}/>
            <Route path ="/register" element={<RegisterPage/>}/> 
            <Route path ="/about" element={<AboutPage/>}/>  
            <Route path ="/urls" element={<ShortUrlsTablePage/>}/> 
            <Route path='*'element={<NotFoundPage/>}/>
        </Routes>          
    );
};

function Logout() {
    const { userStore } = useStore();

    userStore.logout();

    return (
        <Navigate to="/urls" replace={true}/>
    )
}
export default AllRoutes;