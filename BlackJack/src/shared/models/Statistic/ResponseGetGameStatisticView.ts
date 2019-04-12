import { PlayerStatisticView } from './PlayerStatisticView';

import { ResponseWinnerGameView } from '../Game/ResponseWinnerGameView';

export class ResponseGetGameStatisticView {
    gameId: string;
    bots: Array<PlayerStatisticView>;
    user: PlayerStatisticView;
    cardsleft: number;
    winner: ResponseWinnerGameView;
}
