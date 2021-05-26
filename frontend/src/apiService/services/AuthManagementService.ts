/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { UserLogin } from '../models/UserLogin';
import type { UserRegistration } from '../models/UserRegistration';
import { request as __request } from '../core/request';

export class AuthManagementService {

    /**
     * @returns any Success
     * @throws ApiError
     */
    public static async register({
requestBody,
}: {
requestBody?: UserRegistration,
}): Promise<any> {
        const result = await __request({
            method: 'POST',
            path: `/api/AuthManagement/Register`,
            body: requestBody,
        });
        return result.body;
    }

    /**
     * @returns any Success
     * @throws ApiError
     */
    public static async login({
requestBody,
}: {
requestBody?: UserLogin,
}): Promise<any> {
        const result = await __request({
            method: 'POST',
            path: `/api/AuthManagement/Login`,
            body: requestBody,
        });
        return result.body;
    }

}