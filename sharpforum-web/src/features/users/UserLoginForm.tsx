//import { ErrorMessage, Form, Formik } from 'formik';
import { observer } from 'mobx-react-lite';
import React from 'react';
//import MyTextInput from '../../app/common/form/MyTextInput';
import { useStore } from '../../app/stores/store';

export default observer(function UserLoginForm() {
    const { userStore } = useStore();
    return (
        <p>user login form</p>
    );
});