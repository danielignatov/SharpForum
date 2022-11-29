import { useState } from "react";
import { Link as RouterLink, useNavigate } from 'react-router-dom';
import { useAuth } from "../../../contexts/auth.context";
import { authenticationService } from "../../../services/authentication.service";

import jwt_decode from "jwt-decode";

import * as Yup from 'yup';
import { useFormik, Form, FormikProvider } from "formik";
import VisibilityOffIcon from '@mui/icons-material/VisibilityOff';
import VisibilityIcon from '@mui/icons-material/Visibility';
import {
    Icon,
    Link,
    Stack,
    TextField,
    IconButton,
    InputAdornment,
} from '@mui/material';
import { LoadingButton } from '@mui/lab';


export default function LoginForm() {
    const navigate = useNavigate();
    const [showPassword, setShowPassword] = useState(false);
    const { setCurrentUser } = useAuth();

    const LoginSchema = Yup.object().shape({
        email: Yup.string().email('Email must be a valid email address').required('Email is required'),
        password: Yup.string().required('Password is required')
    });

    const formik = useFormik({
        initialValues: {
            email: '',
            password: '',
            // remember: true
        },
        validationSchema: LoginSchema,
        onSubmit: () => {
            console.log('Form submited', values);
            authenticationService.login(values.email, values.password)
                .then(response => response.json())
                .then((response) => {
                    let decodedUser = jwt_decode(response.token);

                    let user = {
                        nameId: decodedUser.nameid,
                        role: decodedUser.Role,
                        email: decodedUser.email,
                        token: response.token
                    };

                    localStorage.setItem('user', JSON.stringify(user));
                    setCurrentUser(user);
                    setSubmitting(false);
                    navigate('/', { replace: true });
                })
                .catch((error) => {
                    setSubmitting(false);
                    console.log('error: ', error);
                })
        }
    });

    const { errors, touched, values, isSubmitting, setSubmitting, handleSubmit, getFieldProps } = formik;

    const handleShowPassword = () => {
        setShowPassword((show) => !show);
    }

    return (
        <FormikProvider value={formik}>
            <Form autoComplete="off" noValidate onSubmit={handleSubmit}>
                <Stack spacing={3}>
                    <TextField
                        fullWidth
                        autoComplete="email"
                        type="email"
                        label="Email address"
                        {...getFieldProps('email')}
                        error={Boolean(touched.email && errors.email)}
                        helperText={touched.email && errors.email}
                    />

                    <TextField
                        fullWidth
                        label="Password"
                        autoComplete="current-password"
                        type={showPassword ? 'text' : 'password'}
                        {...getFieldProps('password')}
                        InputProps={{
                            endAdornment: (
                                <InputAdornment position="end">
                                    <IconButton onClick={handleShowPassword} edge="end">
                                        <Icon icon={showPassword ? VisibilityIcon : VisibilityOffIcon} />
                                    </IconButton>
                                </InputAdornment>
                            )
                        }}
                        error={Boolean(touched.password && errors.password)}
                        helperText={touched.password && errors.password}
                    />
                </Stack>

                <Stack direction="row" alignItems="center" justifyContent="space-between" sx={{ my: 2 }}>
                    {/* <FormControlLabel
                        control={<Checkbox {...getFieldProps('remember')} checked={values.remember} />}
                        label="Remember me"
                    /> */}

                    <Link component={RouterLink} variant="subtitle2" to="#" >
                        Forgot Password
                    </Link>
                </Stack>

                <LoadingButton
                    fullWidth
                    size="large"
                    type="submit"
                    variant="contained"
                    loading={isSubmitting}
                >
                    Login
                </LoadingButton>
            </Form>
        </FormikProvider>
    )
};