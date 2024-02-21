export interface Pagination<T> {
  pageIndex: number
  pageSize: number
  pageCount: number
  data: T
}

export interface CategoryData<T> {
  data: T
}
