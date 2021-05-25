/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { EmployeeData } from '../models/EmployeeData';
import { request as __request } from '../core/request';

export class EmployeeDataService {

    /**
     * @returns EmployeeData Success
     * @throws ApiError
     */
    public static async getEmployeeDataService({
aFrom,
aTo,
}: {
aFrom?: string,
aTo?: string,
}): Promise<Array<EmployeeData>> {
        const result = await __request({
            method: 'GET',
            path: `/api/EmployeeData`,
            query: {
                'aFrom': aFrom,
                'aTo': aTo,
            },
        });
        return result.body;
    }

}