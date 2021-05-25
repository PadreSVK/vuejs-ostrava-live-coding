/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { UserRole } from '../models/UserRole';
import { request as __request } from '../core/request';

export class RoleService {

    /**
     * @returns any Success
     * @throws ApiError
     */
    public static async postRoleService({
requestBody,
}: {
requestBody?: UserRole,
}): Promise<any> {
        const result = await __request({
            method: 'POST',
            path: `/api/Role/AddToRole`,
            body: requestBody,
        });
        return result.body;
    }

    /**
     * @returns any Success
     * @throws ApiError
     */
    public static async postRoleService1({
requestBody,
}: {
requestBody?: UserRole,
}): Promise<any> {
        const result = await __request({
            method: 'POST',
            path: `/api/Role/RemoveFromRole`,
            body: requestBody,
        });
        return result.body;
    }

    /**
     * @returns any Success
     * @throws ApiError
     */
    public static async postRoleService2({
requestBody,
}: {
requestBody?: UserRole,
}): Promise<any> {
        const result = await __request({
            method: 'POST',
            path: `/api/Role/CreateRole`,
            body: requestBody,
        });
        return result.body;
    }

    /**
     * @returns any Success
     * @throws ApiError
     */
    public static async postRoleService3({
requestBody,
}: {
requestBody?: UserRole,
}): Promise<any> {
        const result = await __request({
            method: 'POST',
            path: `/api/Role/DeleteRole`,
            body: requestBody,
        });
        return result.body;
    }

}