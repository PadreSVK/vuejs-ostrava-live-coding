/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import { request as __request } from '../core/request';

export class UserManagementService {

    /**
     * @returns any Success
     * @throws ApiError
     */
    public static async getUserManagementService(): Promise<any> {
        const result = await __request({
            method: 'GET',
            path: `/api/UserManagement/GetUserList`,
        });
        return result.body;
    }

    /**
     * @returns any Success
     * @throws ApiError
     */
    public static async getUserManagementService1({
aId,
}: {
aId?: string,
}): Promise<any> {
        const result = await __request({
            method: 'GET',
            path: `/api/UserManagement/GetUserById`,
            query: {
                'aId': aId,
            },
        });
        return result.body;
    }

    /**
     * @returns any Success
     * @throws ApiError
     */
    public static async postUserManagementService(): Promise<any> {
        const result = await __request({
            method: 'POST',
            path: `/api/UserManagement/ChangePassword`,
        });
        return result.body;
    }

}