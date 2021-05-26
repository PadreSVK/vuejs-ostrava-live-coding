/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { AuthResult } from '../models/AuthResult';
import type { RegistrationResponse } from '../models/RegistrationResponse';
import type { UserLogin } from '../models/UserLogin';
import type { UserRegistration } from '../models/UserRegistration';
import { request as __request } from '../core/request';

export class AuthManagementService {

    /**
     * @returns RegistrationResponse Success
     * @throws ApiError
     */
    public static async register({
requestBody,
}: {
requestBody?: UserRegistration,
}): Promise<RegistrationResponse> {
        const result = await __request({
            method: 'POST',
            path: `/api/AuthManagement/Register`,
            body: requestBody,
        });
        return result.body;
    }

    /**
     * @returns AuthResult Success
     * @throws ApiError
     */
    public static async login({
requestBody,
}: {
requestBody?: UserLogin,
}): Promise<AuthResult> {
        const result = await __request({
            method: 'POST',
            path: `/api/AuthManagement/Login`,
            body: requestBody,
        });
        return result.body;
    }

}