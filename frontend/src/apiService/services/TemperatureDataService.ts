/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Filters } from '../models/Filters';
import type { TemperatureData } from '../models/TemperatureData';
import { request as __request } from '../core/request';

export class TemperatureDataService {

    /**
     * @returns TemperatureData Success
     * @throws ApiError
     */
    public static async getTemperatureDataService({
aFrom,
aTo,
}: {
aFrom?: string,
aTo?: string,
}): Promise<Array<TemperatureData>> {
        const result = await __request({
            method: 'GET',
            path: `/api/TemperatureData`,
            query: {
                'aFrom': aFrom,
                'aTo': aTo,
            },
        });
        return result.body;
    }

    /**
     * @returns TemperatureData Success
     * @throws ApiError
     */
    public static async postTemperatureDataService({
requestBody,
}: {
requestBody?: Filters,
}): Promise<Array<TemperatureData>> {
        const result = await __request({
            method: 'POST',
            path: `/api/TemperatureData/PostTeste`,
            body: requestBody,
        });
        return result.body;
    }

}