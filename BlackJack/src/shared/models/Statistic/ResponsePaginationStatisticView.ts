import { StatisticStatisticView } from "./statisticStatisticView";

export class ResponsePaginationStatisticView {
    page: Array<StatisticStatisticView>;
    pageNumber: number;
    itemsOnPage: number;
    totalItems: number;
    totalPages: number;
}
