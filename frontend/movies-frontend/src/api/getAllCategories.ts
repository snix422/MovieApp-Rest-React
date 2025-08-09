import { apiClient } from './axiosConfig';

export const getAllCategories = async () => {
  const res = await apiClient.get('/category');
  return res.data;
};
