import { PlayerStatisticView } from './playerStatisticView';

export class ResponseGetGameStatisticView {
    gameId: string;
    bots: Array<PlayerStatisticView>;
    user: PlayerStatisticView;
    winner: string;
}
