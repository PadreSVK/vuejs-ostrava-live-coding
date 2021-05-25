/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { ClaimRequest } from '../models/ClaimRequest';
import { request as __request } from '../core/request';

export class ClaimService {

    /**
     * @returns any Success
     * @throws ApiError
     */
    public static async postClaimService({
requestBody,
}: {
requestBody?: ClaimRequest,
}): Promise<any> {
        const result = await __request({
            method: 'POST',
            path: `/api/Claim/AddClaim`,
            body: requestBody,
        });
        return result.body;
    }

    /**
     * @returns any Success
     * @throws ApiError
     */
    public static async postClaimService1({
requestBody,
}: {
requestBody?: ClaimRequest,
}): Promise<any> {
        const result = await __request({
            method: 'POST',
            path: `/api/Claim/AddOrUpdateClaim`,
            body: requestBody,
        });
        return result.body;
    }

    /**
     * @returns any Success
     * @throws ApiError
     */
    public static async postClaimService2({
requestBody,
}: {
requestBody?: ClaimRequest,
}): Promise<any> {
        const result = await __request({
            method: 'POST',
            path: `/api/Claim/RemoveClaim`,
            body: requestBody,
        });
        return result.body;
    }

}